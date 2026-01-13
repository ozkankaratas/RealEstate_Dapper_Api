// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {

    var deleteButtons = document.querySelectorAll('.btn-sil');

    deleteButtons.forEach(function (button) {
        button.addEventListener('click', function (e) {
            e.preventDefault();
            var url = this.getAttribute('href');

            if (typeof Swal === 'undefined') {
                console.error("SweetAlert2 kütüphanesi yüklenmemiş!");
                if (confirm("Silmek istediğinize emin misiniz?")) {
                    window.location.href = url;
                }
                return;
            }

            Swal.fire({
                title: 'Silmek istiyor musunuz?',
                text: "Bu işlemi geri alamazsınız!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#3085d6',
                confirmButtonText: 'Evet, Sil',
                cancelButtonText: 'Hayır, Vazgeç'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = url;
                }
            });
        });
    });
});