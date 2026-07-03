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

    return response.json();
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
