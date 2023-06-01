// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener('scroll', function() {
    var menuImg1 = document.getElementById('menu-img1');
    var menuImg2 = document.getElementById('menu-img2');
    var menuImg3 = document.getElementById('menu-img3');

    var position = menuImg1.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (position < screenPosition && position > -menuImg1.offsetHeight) {
        menuImg1.style.opacity = '1';
        menuImg1.style.transform = 'translateY(0)';
    } else {
        menuImg1.style.opacity = '0';
        menuImg1.style.transform = 'translateY(100px)'; // Ajusta el valor según sea necesario
    }

    if (position < screenPosition - 100 && position > -menuImg2.offsetHeight) {
        menuImg2.style.opacity = '1';
        menuImg2.style.transform = 'translateY(0)';
    } else {
        menuImg2.style.opacity = '0';
        menuImg2.style.transform = 'translateY(100px)'; // Ajusta el valor según sea necesario
    }

    if (position < screenPosition - 200 && position > -menuImg3.offsetHeight) {
        menuImg3.style.opacity = '1';
        menuImg3.style.transform = 'translateY(0)';
    } else {
        menuImg3.style.opacity = '0';
        menuImg3.style.transform = 'translateY(100px)'; // Ajusta el valor según sea necesario
    }
});

  