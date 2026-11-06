const blogs = [
    {
        titel: "Zuid-Korea vakantie🛫",
        categorie: "Vakantie",
        startdatum: "2026-07-29",
        einddatum: "2026-08-10",
        afbeelding: "../Images/Zuid_Korea.jpg",
        beschrijving: "Ik ben samen met mijn gezin naar Zuid-Korea geweest voor een vakantie. Het was snikheet, maar er waren wel leuke plekken om te bezoeken. Als het niet in de zomer was, dan zou het een betere vakantie worden."
    },
    {
        titel: "Collectorsland🎴🎮",
        categorie: "Evenement",
        startdatum: "2026-08-29",
        einddatum: "2026-08-29",
        afbeelding: "../Images/Collectorsland_2.0.jpg",
        beschrijving: "Vandaag ben ik naar het evenement Collectorsland bij de Broodfabriek geweest. Ik heb daar Pokémon kaarten gekocht. Verder heb ik aan toernooien deelgenomen van Super Smash Bros Ultimate en Mario Kart World. Voor Super Smash Bros Ultimate had ik gewonnen, maar voor Mario Kart World had ik verloren."
    },
    {
        titel: "Eerste dag op school🏫",
        categorie: "School",
        startdatum: "2026-08-31",
        einddatum: "2026-08-31",
        afbeelding: "../Images/De_Haagse_hogeschool.jpg",
        beschrijving: "Dit was de eerste dag van mijn tweede jaar aan de Haagse Hogeschool. We begonnen met een introductie waarbij we informatie kregen over het derde semester."
    }
];

function renderBlogs(filter = "Alles") {
    const constrainer = document.getElementById("blog-container");

    constrainer.innerHTML = "";

    let gefilterdeBlogs = blogs;

    if (filter !== "Alles") {
        gefilterdeBlogs = blogs.filter(
            blog => blog.categorie === filter
        );
    }

    gefilterdeBlogs.forEach(blog => {
        const card = document.createElement("div");
        card.classList.add("card");

        const titel = document.createElement("h2");
        titel.textContent = blog.titel;

        const periode = document.createElement("p");

        const start = new Date(blog.startdatum).toLocaleDateString("nl-NL");
        const eind = new Date(blog.einddatum).toLocaleDateString("nl-NL");

        if (blog.startdatum === blog.einddatum) {
            periode.textContent = start;
        }
        else {
            periode.textContent = `${start} t/m ${eind}`;
        }

        if (blog.afbeelding) {
            const img = document.createElement("img");
            img.src = blog.afbeelding;
            img.alt = blog.titel;

            card.appendChild(img);
        }
        
        const beschrijving = document.createElement("p");
        beschrijving.textContent = blog.beschrijving;

        card.appendChild(titel);
        card.appendChild(periode);
        card.appendChild(beschrijving);

        constrainer.appendChild(card);
    });
}

const filterBlogs = document.getElementById("filter-blogs");

filterBlogs.addEventListener("change", () => {
    renderBlogs(filterBlogs.value);
});

renderBlogs();