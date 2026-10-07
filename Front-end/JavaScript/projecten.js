const projecten = [
    {
        id: 1,
        naam: "Databases",
        beschrijving: "Klassendiagrammen, RRM's en SQL queries",
        links: [
            {
            tekst: "Klassendiagrammen",
            url: "https://1drv.ms/w/c/09c3315228660e3b/IQBifP114Z6sR4m97gTfbL0cAWRXhxUi8egwqZiiP2HqRS4?e=ICzkdv"
        },
            {
            tekst: "RRM's",
            url: "https://1drv.ms/w/c/09c3315228660e3b/IQC6-Othw-oXQ6uiYldjdoMTARjQXNKukJHuh1z8ef6Z3LI?e=J8ibFZ"
        },
        {
            tekst: "Queries",
            url: "https://1drv.ms/w/c/09c3315228660e3b/IQCYzdt5cjNiQp_0IGhX6431AbCLSPl5KCyRAo2XotRlORU?e=EGPtcD"
        }
        ]
    },
    {
        id: 2,
        naam: "Vang de volger",
        beschrijving: "Een spel waarbij je de volger probeert te vangen.",
        afbeelding: "Vang_de_volger.png"
    },
    {
        id: 3,
        naam: "Conway's Game of Life",
        beschrijving: "Een cellulaire automaat die de evolutie van cellen simuleert.",
        afbeelding: "Conway's_game_of_life.png"
    }
];

function renderProjecten() {
    const container = document.getElementById("projecten-container");

    container.innerHTML = "";

    projecten.forEach(project => {

        const card = document.createElement("div");
        card.classList.add("card");

        const titel = document.createElement("h2");
        titel.textContent = project.naam;

        const beschrijving = document.createElement("p");
        beschrijving.textContent = project.beschrijving;
    
        card.appendChild(titel); 
        card.appendChild(beschrijving);
    
        if (project.afbeelding) {
            const img = document.createElement("img");
            img.src = project.afbeelding;
            img.alt = project.naam;
            card.appendChild(img);
        }

        if (project.links) {
            project.links.forEach(item => {
                const link = document.createElement("a");

                link.href = item.url;
                link.textContent = item.tekst;
                link.target = "_blank";
                link.rel = "noopener noreferrer";

                card.appendChild(link);
            });
        }
        container.appendChild(card);
    });
}

const sorteerKnop = document.getElementById("sorteer-knop");

let gesorteerd = false;

sorteerKnop.addEventListener("click", () => {
    if (!gesorteerd) {
        projecten.sort((a, b) => a.naam.localeCompare(b.naam));
        sorteerKnop.textContent = "Origineel";
    }
    else {
        projecten.sort((a,b) => a.id - b.id);
        sorteerKnop.textContent = "Sorteer alfabetisch"; 
    }

    gesorteerd = !gesorteerd;
    renderProjecten();
});

renderProjecten();