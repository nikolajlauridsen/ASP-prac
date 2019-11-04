const uri = 'https://localhost:44350/api/movie'
let movies = [];

function getMovies() {
    // Fetch movies from API
    fetch(uri)
        .then(response => response.json())                               // Turn em into json
        .then(data => _displayMovies(data))                              // Call _displayMovies with the data
        .catch(error => console.error('Unable to get items.', error));   // Catch error and display in console
}

function reserveSeat(id) {
    console.log("Asked to reserve id: " + id);
    fetch(uri + '/BookMovie/' + id, { method: 'PUT' })                  // Send put request to api
        .then(response => console.log(response))
    getMovies();                                                        // Refresh movies
}


function _displayMovies(data) {
    const mContainer = document.getElementById('MovieContainer');  // Get the row for the movies
    mContainer.innerHTML = '';                                     // Reset the row

    data.forEach(item => {                                        // Loop throught the elements with lambda
        console.log(item);
        card = document.createElement('div');                 // Create card div
        card.setAttribute('class', 'card');                       // Set the class to card
        card.style.cssText = "width: 18rem; margin: 1rem;"        // Set style tags

        let cardBody = document.createElement('div');             // Create card body div
        cardBody.setAttribute('class', 'card-body');              // Set class to card-body

        let movieTitle = document.createElement('h5');            // Create heading for title
        movieTitle.setAttribute('class', 'card-title');           // Set class to card title
        movieTitle.innerText = item.title;                        // Set title text to movie title

        let subTitle = document.createElement('h8');              // Create subtitle heading
        subTitle.setAttribute('class', 'card-subtitle mb-2 text-muted');    // Set class to card card-subtitle
        subTitle.innerText = item.genre                           // Set text of subtitle to genre from movie

        let description = document.createElement('p');            // Create paragraph element
        description.setAttribute('class', 'card-text');           // Add card-text class
        description.innerText = item.description;                 // Set text to description

        let numSeats = document.createElement('p');
        numSeats.setAttribute('class', 'card-text');
        numSeats.innerText = "Seats: " + item.numSeats

        let reserveBtn = document.createElement('button');              // Create button element
        reserveBtn.setAttribute('class', 'btn btn-primary');            // Style zeh button
        reserveBtn.setAttribute('onclick', `reserveSeat(${item.id})`)   // Register on click with ID
        reserveBtn.innerText = 'Reserve ticket';                        // Set text


        cardBody.appendChild(movieTitle);                        // Append elements, from innermost to outermost objects
        cardBody.appendChild(subTitle);
        cardBody.appendChild(description);
        cardBody.appendChild(numSeats);
        cardBody.appendChild(reserveBtn);
        card.appendChild(cardBody);
        mContainer.appendChild(card);

    })
}