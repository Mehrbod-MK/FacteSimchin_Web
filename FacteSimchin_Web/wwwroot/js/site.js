// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/***************** HELPERS *****************/
function isNullOrWhitespace(str) {
    if (str === null || str === undefined) return true;
    return str.trim().length === 0;
}

function displayModal(title, text) {
    const myModal = new bootstrap.Modal(document.getElementById("myModal"));
    document.getElementById("modalTitle").textContent = title;
    document.getElementById("modalBody").textContent = text;
    myModal.show();
}

function setElementActive(id, active) {
    const element = document.getElementById(id);
    element.disabled = !active;
}

function setTextContent(id, text) {
    const element = document.getElementById(id);
    element.textContent = text;
}
/*******************************************/

/***************** API *****************/
async function api(
    url,
    { method = "GET", data = null, token = null, timeout = 10000 } = {}
) {
    const headers = { "Content-Type": "application/json" };
    if (token) headers["Authorization"] = `Bearer ${token}`;

    const options = { method, headers };
    if (data) options.body = JSON.stringify(data);

    const response = await Promise.race([
        fetch(url, options),
        new Promise((_, reject) =>
            setTimeout(() => reject(new Error("Timeout")), timeout)
        )
    ]);

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`HTTP ${response.status}\n${errorText}`);
    }

    const raw = await response.text();
    return raw ? JSON.parse(raw) : null;
}

const apiClient = {
    get: (url, config = {}) =>
        api(url, { ...config, method: "GET" }),

    post: (url, data, config = {}) =>
        api(url, { ...config, method: "POST", data }),

    put: (url, data, config = {}) =>
        api(url, { ...config, method: "PUT", data }),

    delete: (url, config = {}) =>
        api(url, { ...config, method: "DELETE" })
};
/***************************************/

/***************** NEW GAME *****************/
function godNewGame() {
    setElementActive("btnStartNewGame", false);
    setTextContent("btnStartNewGame", "لطفاً کمی صبر کنید...");
    const godNameString = document.getElementById("txtGodName").value;
    apiClient.post("/api/v1/game/newgame", { godName: godNameString })
        .then(newGameInfos => {
            setTextContent("btnStartNewGame", "با موفقیت وارد شدید!");
            window.open(`/game/god/listplayers?sessionId=${newGameInfos.sessionId}&godSecret=${newGameInfos.godSecret}`, "_blank")
                .focus();
        })
        .catch(error => {
            displayModal("خطا", error);
            setElementActive("btnStartNewGame", true);
            setTextContent("btnStartNewGame", "شروع بازی");
        });
};
/********************************************/

/***************** GOD SCRIPTS *****************/
function displayPlayersNamesTable(sessionId, godSecret) {
    let btnRefreshPlayersNamesList = "btnRefreshPlayersNamesList";
    setElementActive(btnRefreshPlayersNamesList, false);
    setTextContent(btnRefreshPlayersNamesList, "در حال بارگیری...");
    apiClient.post("/api/v1/game/get_list_joined_player_names", { SessionId: sessionId, GodSecret: godSecret })
        .then(joinedPlayers => {
            let tableListPlayersNames = document.getElementById("tableListPlayersNames");
            tableListPlayersNames.innerHTML = "";
            let lblNumPlayers = document.getElementById("lblNumPlayers");
            lblNumPlayers.innerHTML = `تعداد بازیکنان:  ${joinedPlayers.players.length}`;
            joinedPlayers.players.forEach(player => {
                tableListPlayersNames.innerHTML += `
                <tr>
                    <th class="text-white" scope="row">${player.id}</th>
                    <td class="text-white">${player.name}</td>
                    <td><button class="btn btn-danger">اخراج</button></td>
                </tr>`;
            });
            setElementActive(btnRefreshPlayersNamesList, true);
            setTextContent(btnRefreshPlayersNamesList, "تازه‌سازی لیست");
        })
        .catch(error => {
            displayModal("خطا", error);
            setElementActive(btnRefreshPlayersNamesList, true);
            setTextContent(btnRefreshPlayersNamesList, "تازه‌سازی لیست");
        })
}
/***********************************************/

/***************** PLAYER SCRIPTS *****************/
function joinGame(sessionId) {
    let btnJoinGame = "btnJoinGame";
    setElementActive(btnJoinGame, false);
    setTextContent(btnJoinGame, "لطفاً کمی صبر کنید...");
    const playerName = document.getElementById("txtPlayerName").value;
    apiClient.post("/api/v1/game/join_game_session", { SessionId: sessionId, PlayerName: playerName })
        .then(playerJoinedInfos => {
            setTextContent(btnJoinGame, "با موفقیت وارد بازی شدید!");
        })
        .catch(error => {
            displayModal("خطا", error);
            setElementActive(btnJoinGame, true);
            setTextContent(btnJoinGame, "پیوستن به بازی");
        })
}
/**************************************************/

/***************** CHOOSE ROLES SCRIPTS  *****************/
const chosenRoles = new Map();
function incrementOrDecrementRoleCount(roleId, isInc) {
    let roleCount = 0;
    if (chosenRoles.has(roleId)) {
        if (isInc) {
            roleCount = chosenRoles.get(roleId) + 1;
        }
        else {
            roleCount = chosenRoles.get(roleId) - 1;
            if (roleCount < 0) {
                roleCount = 0;
            }
        }
        if (roleCount == 0) {
            chosenRoles.delete(roleId);
        }
        else {
            chosenRoles.set(roleId, roleCount);
        }
    }
    else if(isInc) {
        roleCount = 1;
        chosenRoles.set(roleId, roleCount)
    }
    setTextContent(`lblCount${roleId}`, roleCount.toString());
}
function chooseOrUnchooseRole(roleId, className) {
    let isChosen = false;
    if (chosenRoles.has(roleId)) {
        isChosen = false;
        chosenRoles.delete(roleId);
    }
    else {
        isChosen = true;
        chosenRoles.set(roleId, 1);
    }
    let cardObject = document.getElementById(`card_${roleId}`);
    let roleTitleObject = document.getElementById(`roleName_${roleId}`);
    let textClass = 'text-white';
    if (className === 'warning') {
        textClass = 'text-black';
    }
    if (isChosen) {
        cardObject.classList.add(`bg-${className}`);
        roleTitleObject.classList.add(textClass);
        setTextContent(`btnChooseRole_${roleId}`, "لغو انتخاب");
    }
    else {
        cardObject.classList.remove(`bg-${className}`);
        roleTitleObject.classList.remove(textClass);
        setTextContent(`btnChooseRole_${roleId}`, "انتخاب");
    }
}
/*********************************************************/
