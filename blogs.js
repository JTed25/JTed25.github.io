const blogs = [
    {
        titel: "Zuid-Korea vakantie",
        startdatum: "2026-07-29",
        einddatum: "2026-08-10",
        beschrijving: "Ik ben samen met mijn gezin naar Zuid-Korea geweest voor een vakantie. Het was snikheet, maar er waren wel leuke plekken om te bezoeken. Als het niet in de zomer was, dan zou het een betere vakantie worden."
    },
    {
        titel: "Collectorsland",
        startdatum: "2026-08-29",
        einddatum: "2026-08-29",
        beschrijving: "Vandaag ben ik naar het evenement Collectorsland bij de Broodfabriek geweest. Ik heb daar Pokémon kaarten gekocht. Verder heb ik aan toernooien deelgenomen van Super Smash Bros Ultimate en Mario Kart World. Voor Super Smash Bros Ultimate had ik gewonnen, maar voor Mario Kart World had ik verloren."
    },
    {
        titel: "Eerste dag op school",
        startdatum: "2026-08-31",
        einddatum: "2026-08-31",
        beschrijving: "Dit was de eerste dag van mijn tweede jaar aan de Haagse Hogeschool. We begonnen met een introductie waarbij we informatie kregen over het derde semester."
    }
];

blogs.sort((a,b) => a.titel.localeCompare(b.titel));

function renderBlogs() {
    const constrainer = document.getElementById("blog-container");

    
}