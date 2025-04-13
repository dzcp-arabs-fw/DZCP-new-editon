const i18n = {
    en: {
        welcome: "Welcome to DZCP Framework",
        about: "About DZCP",
        events: "Events",
        structure: "Structure",
        docs: "Documentation",
    },
    ar: {
        welcome: "مرحبًا بكم في إطار DZCP",
        about: "عن DZCP",
        events: "الأحداث",
        structure: "الهيكل",
        docs: "التوثيق",
    },
};

function setLanguage(lang) {
    document.querySelectorAll("[data-i18n]").forEach((element) => {
        const key = element.getAttribute("data-i18n");
        element.textContent = i18n[lang][key];
    });
}

// Example Usage
setLanguage("ar");