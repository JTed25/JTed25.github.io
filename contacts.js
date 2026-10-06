const formulier = document.getElementById("contact-form");
const feedback = document.getElementById("feedback");

formulier.addEventListener("submit", (event) => {
    event.preventDefault();

    const naam = document.getElementById("naam").value.trim();
    const email = document.getElementById("email").value.trim();
    const bericht = document.getElementById("bericht").value.trim();

    document.getElementById("naam-fout").textContent = "";
    document.getElementById("email-fout").textContent = "";
    document.getElementById("bericht-fout").textContent = "";
    feedback.textContent = "";

    let geldig = true;

    if (naam === "") {
        document.getElementById("naam-fout").textContent = "Vul uw naam in.";
        geldig = false;
    }

    if (email === "") {
        document.getElementById("email-fout").textContent = "Vul uw e-mailadres in.";
        geldig = false;
    }

    else if (!email.includes("@")) {
        document.getElementById("email-fout").textContent = "Voer een geldige e-mailadres in.";
        geldig = false;
    }

    if (bericht === "") {
        document.getElementById("bericht-fout").textContent = "Vul een bericht in.";
        geldig = false;
    }

    else if (bericht.length < 10) {
        document.getElementById("bericht-fout").textContent = "Bericht moet minimaal 10 tekens bevatten.";
        geldig = false;
    }

    if (!geldig) {
        return;
    }

    feedback.style.color = "green";
    feedback.textContent = "Bericht succesvol verzonden!";

    formulier.reset();
});