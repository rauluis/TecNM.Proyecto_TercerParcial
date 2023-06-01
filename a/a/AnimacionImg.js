// Animación de deslizamiento de las imágenes del menú al hacer scroll
window.addEventListener('scroll', function() {
    var menuImg1 = document.getElementById('menu-img1');
    var menuImg2 = document.getElementById('menu-img2');
    var menuImg3 = document.getElementById('menu-img3');
  
    var position = menuImg1.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;
  
    if (position < screenPosition) {
      menuImg1.style.opacity = '1';
      menuImg1.style.transform = 'translateY(0)';
    }
  
    if (position < screenPosition - 100) {
      menuImg2.style.opacity = '1';
      menuImg2.style.transform = 'translateY(0)';
    }
  
    if (position < screenPosition - 200) {
      menuImg3.style.opacity = '1';
      menuImg3.style.transform = 'translateY(0)';
    }
  });
  
  