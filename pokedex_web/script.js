document.addEventListener('DOMContentLoaded', () => {
    const mosaic = document.getElementById('mosaic');
    const colors = ['#000000', '#FFFFFF', '#808080']; // Negro, blanco y gris

    // Crear mosaico
    for (let i = 0; i < 100; i++) {
        const tile = document.createElement('div');
        tile.classList.add('tile');
        mosaic.appendChild(tile);
    }

    // Cambiar colores aleatoriamente
    setInterval(() => {
        const tiles = document.querySelectorAll('.tile');
        tiles.forEach(tile => {
            const randomColor = colors[Math.floor(Math.random() * colors.length)];
            tile.style.backgroundColor = randomColor;
        });
    }, 1000); // Cambia cada segundo

    

    
});
