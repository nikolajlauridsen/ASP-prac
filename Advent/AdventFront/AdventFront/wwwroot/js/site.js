function showCard(day) {
    console.log(day);
    let card = document.getElementById("fact-card");
    let content = document.getElementById("fact-paragraph");

    let daycard = document.getElementById("day-" + day);
    console.log(daycard);
    daycard.classList.toggle("swing-left-fwd");

    card.style.display = "flex";

    content.textContent = "Loading facc..."

    fetch('https://localhost:44387/api/adventfacts/' + day)
        .then(res => {
            if (res.ok) {
                return res.json();
            } else {
                content.textContent = "You're too early you little rascal, coal for you..."
                return null;
            }     
        }).then(data => {
            if (data != null) {
                console.log(data);
                content.textContent = data.fact;
            }
        }).catch(error => {
            console.log(error);
            content.textContent = "Don't really know what happened, check the log.";
        })
}

function closeCard() {
    let card = document.getElementById("fact-card");
    console.log(card);
    card.style.display = "none";
}
