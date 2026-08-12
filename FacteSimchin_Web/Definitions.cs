using FacteSimchin_Web.Models;
using FacteSimchin_Web.Models.Enums;
using System.Collections.ObjectModel;

namespace FacteSimchin_Web
{
    public static class Definitions
    {
        public static readonly ReadOnlyDictionary<GameRoles, RoleDefinitionModel> SupportedGameRoles = new(new Dictionary<GameRoles, RoleDefinitionModel>()
            {
                { GameRoles.Citizen, new RoleDefinitionModel() {
                        Name = "شهروند",
                        Description = "شهروند، هیچ توانایی خاصی در بازی ندارد و وظیفه آن، کمک به سایر هم‌تیمی‌های خود جهت جلوگیری از برد مافیا و بیرون شدن سایر شهروندان توسط مافیا در بازی است.",
                        IsMafia = false,
                        IsPlural = true,
                        AvatarUri = "./../img/avatars/role_citizen.png"
                    } 
                },
                { GameRoles.Mafia, new RoleDefinitionModel() {
                        Name = "مافیا",
                        Description = "مافیا، قدرت خاصی ندارد، اما وظیفه آن، کمک به هم‌تیمی‌های مافیایی خود برای بیرون کردن تمامی شهروندان از بازی است.",
                        IsMafia = true,
                        IsPlural = true,
                        AvatarUri = "./../img/avatars/role_mafia.png"
                    }
                },
                { GameRoles.GodFather, new RoleDefinitionModel() {
                        Name = "پدرخوانده",
                        Description = "پدرخوانده، سردسته و رئیس تیم مافیاست، که شب تصمیم می‌گیرد چه عملیاتی توسط تیم مافیا انجام شود. استعلام کارآگاه از این شخصیت برای اولین بار، منفی است.",
                        IsMafia = true,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_godfather.png"
                    }
                },
                { GameRoles.Negotiator, new RoleDefinitionModel() {
                        Name = "مذاکره‌کننده",
                        Description = "در صورتی که حداقل 1 نفر از تیم مافیا بیرون برود، مذاکره‌کننده می‌تواند یک شهروند ساده را به تیم مافیا دعوت کند. در صورتی که بازیکن هدف نقش‌دار باشد، مذاکره با شکست مواجه می‌شود.",
                        IsMafia = true,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_negotiator.png"
                    }
                },
                { GameRoles.BombMaker, new RoleDefinitionModel() {
                        Name = "بمب‌گذار",
                        Description = "",
                        IsMafia = true,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_bombmaker.png"
                    }
                },
                { GameRoles.DoctorLecter, new RoleDefinitionModel() {
                        Name = "دکتر لِکتِر",
                        Description = "",
                        IsMafia = true,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_lecter.png"
                    }
                },
                { GameRoles.Detective, new RoleDefinitionModel() {
                        Name = "کارآگاه",
                        Description = "",
                        IsMafia = false,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_detective.png"
                    }
                },
                { GameRoles.Doctor, new RoleDefinitionModel() {
                        Name = "دکتر",
                        Description = "",
                        IsMafia = false,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_doctor.png"
                    }
                },
                { GameRoles.Sniper, new RoleDefinitionModel() {
                        Name = "اسنایپر",
                        Description = "",
                        IsMafia = false,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_sniper.png"
                    }
                },
                { GameRoles.Gunner, new RoleDefinitionModel() {
                        Name = "تفنگ‌دار",
                        Description = "",
                        IsMafia = false,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_gunner.png"
                    }
                },
                { GameRoles.Guardian, new RoleDefinitionModel() {
                        Name = "نگهبان",
                        Description = "",
                        IsMafia = false,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_guardian.png"
                    }
                },
                { GameRoles.Joker, new RoleDefinitionModel() {
                        Name = "جوکر",
                        Description = "",
                        IsMafia = null,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_joker.png"
                    }
                },
                { GameRoles.Bartender, new RoleDefinitionModel() {
                        Name = "ساقی",
                        Description = "",
                        IsMafia = null,
                        IsPlural = false,
                        AvatarUri = "./../img/avatars/role_bartender.png"
                    }
                },
            });
    }
}
