const status = document.getElementById("ghibli-status");
const container = document.getElementById("ghibli-container");
const url = "https://ghibliapi.vercel.app/films"

function laadGhibliFilm() {
    container.innerHTML = "";

    fetch(url)
        .then(response => response.json())
        .then(data => {
            status.textContent = "";

            const randomIndex = Math.floor(Math.random() * data.length);
            const film = data[randomIndex];

            const titel = document.createElement("h3");
            titel.textContent = film.title;

            const beschrijving = document.createElement("p");
            beschrijving.textContent = film.description;

            const regisseur = document.createElement("p");
            regisseur.textContent = `Regisseur: ${film.director}`;

            const jaar = document.createElement("p");
            jaar.textContent = `Uitgebracht: ${film.release_date}`;

            const afbeelding = document.createElement("img");
            afbeelding.src = film.image;
            afbeelding.alt = film.title;

            container.appendChild(afbeelding);
            container.appendChild(titel);
            container.appendChild(regisseur);
            container.appendChild(jaar);
            container.appendChild(beschrijving);
        })
        .catch(error => {
            status.textContent = "Informatie over de Studio Ghibli film kon niet worden geladen.";

            console.log(error);
        });
}

laadGhibliFilm();

document.getElementById("nieuwe-film")
    .addEventListener("click", laadGhibliFilm);