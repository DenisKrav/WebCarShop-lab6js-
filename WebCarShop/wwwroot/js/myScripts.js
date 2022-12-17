//Додавання в localStorage
let counter = 1;

function AddBasket(modelName, price) {
    if (counter == 1) {
        localStorage.clear();
    }
    let car = [modelName, price];
    localStorage.setItem(counter, JSON.stringify(car));
    
    document.querySelector('.basketCounter').innerHTML = counter;

    counter++;
}


//Вивід з localStorage
const mainDiv = document.querySelector('#basEl');

const Maker = (text1, text2) => {
    const div = document.createElement('div');
    div.className = "col-lg-4";
    const h2 = document.createElement('h2');
    const p = document.createElement('p');
    const img = document.createElement('img');
    img.className = "img-thumbnail";
   
    img.src = 'https://localhost:7016/img/carImg.jpg';
    div.appendChild(img);
    h2.textContent = text1;
    div.appendChild(h2);
    p.textContent = text2;    
    div.appendChild(p);

    mainDiv.appendChild(div);
}

window.onload = function () {
    for (let i = 1; i < localStorage.length + 1; i++) {
        data = JSON.parse(localStorage.getItem(i));
        Maker(data[0], data[1]);
    }
}