// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//üye ol sayfası bölümü
document.addEventListener('DOMContentLoaded', (event) => {
    const modal = document.getElementById('register-modal');
    const registerBtn = document.getElementById('register-btn');
    const closeBtn = document.getElementsByClassName('close-btn')[0];

    // Register butonuna tıklanınca modalı aç
    registerBtn.onclick = function () {
        modal.style.display = 'block';
    }

    // Çarpı işaretine tıklanınca modalı kapat
    closeBtn.onclick = function () {
        modal.style.display = 'none';
    }

    // Modal dışına tıklanınca modalı kapat
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }
});