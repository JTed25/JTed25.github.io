const formulier = document.getElementById("contact-form");
const feedback = document.getElementById("feedback");

formulier.addEventListener("submit", (event) => {
    event.preventDefault();

    const naam = document.getElementById("naam").value.trim();
    const email = document.getElementById("email").value.trim();
    const bericht = document.getElementById("bericht").value.trim();

    if (naam === "") {
        feedback.style.color = "red";
        feedback.textContent = "Vul uw naam in";
        return;
    }

    if (email === "") {
        feedback.style.color = "red";
        feedback.textContent = "Vul uw e-mailadres in";
        return;
    }

    if (!email.includes("@")) {
        feedback.style.color = "red";
        feedback.textContent = "Voer een geldige e-mailadres in";
        return;
    }

    if (bericht === "") {
        feedback.style.color = "red";
        feedback.textContent = "Vul een bericht in";
        return;
    }

    feedback.style.color = "green";
    feedback.textContent = "Bericht succesvol verzonden!";

    formulier.reset();
})