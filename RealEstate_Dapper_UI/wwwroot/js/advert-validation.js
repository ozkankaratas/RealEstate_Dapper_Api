
document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('advertForm');

    const priceInput = document.querySelector('input[name="Price"]');
    priceInput.addEventListener('input', function (e) {
        this.value = this.value.replace(/[^0-9.]/g, '');

        const parts = this.value.split('.');
        if (parts.length > 2) {
            this.value = parts[0] + '.' + parts.slice(1).join('');
        }

        let value = this.value.replace(/\./g, '');
        if (value) {
            this.value = value.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
        }

        clearError(this);
    });

    const allInputs = document.querySelectorAll('input[type="text"], textarea, select');
    allInputs.forEach(input => {
        input.addEventListener('input', function () {
            if (this.value.trim()) {
                clearError(this);
            }
        });

        input.addEventListener('change', function () {
            if (this.value.trim()) {
                clearError(this);
            }
        });
    });

    form.addEventListener('submit', function (event) {
        event.preventDefault();

        document.querySelectorAll('.error-message').forEach(el => {
            el.style.display = 'none';
            el.textContent = '';
        });

        document.querySelectorAll('.form-control, .form-select').forEach(el => {
            el.classList.remove('is-invalid');
        });

        let isValid = true;

        const title = document.querySelector('input[name="Title"]');
        if (!title.value.trim()) {
            showError(title, 'İlan Başlığı alanını boş bıraktınız');
            isValid = false;
        }

        const category = document.querySelector('select[name="ProductCategory"]');
        if (!category.value) {
            showError(category, 'İlan Kategorisi alanını boş bıraktınız');
            isValid = false;
        }

        const price = document.querySelector('input[name="Price"]');
        const priceValue = price.value.replace(/,/g, ''); 
        if (!priceValue.trim()) {
            showError(price, 'İlan Fiyatı alanını boş bıraktınız');
            isValid = false;
        } else if (isNaN(priceValue) || parseFloat(priceValue) <= 0) {
            showError(price, 'Lütfen geçerli bir fiyat giriniz');
            isValid = false;
        } else {
            price.value = priceValue;
        }

        // İlan Türü kontrolü
        const type = document.querySelector('select[name="Type"]');
        if (!type.value) {
            showError(type, 'İlan Türü alanını boş bıraktınız');
            isValid = false;
        }

        // Şehir kontrolü
        const city = document.querySelector('select[name="City"]');
        if (!city.value) {
            showError(city, 'Şehir alanını boş bıraktınız');
            isValid = false;
        }

        // İlçe kontrolü
        const district = document.querySelector('select[name="District"]');
        if (!district.value) {
            showError(district, 'İlçe alanını boş bıraktınız');
            isValid = false;
        }

        // Semt kontrolü
        const semt = document.querySelector('select[name="Semt"]');
        if (!semt.value) {
            showError(semt, 'Semt alanını boş bıraktınız');
            isValid = false;
        }

        // Mahalle kontrolü
        const neighborhood = document.querySelector('select[name="Neighborhood"]');
        if (!neighborhood.value) {
            showError(neighborhood, 'Mahalle alanını boş bıraktınız');
            isValid = false;
        }

        // Harita koordinatları kontrolü
        const lat = document.getElementById('lat');
        const lng = document.getElementById('lng');
        if (!lat.value || !lng.value) {
            const mapErrorDiv = document.querySelector('#map').nextElementSibling.nextElementSibling;
            if (mapErrorDiv && mapErrorDiv.classList.contains('error-message')) {
                mapErrorDiv.textContent = 'Haritadan konum seçmeyi boş bıraktınız';
                mapErrorDiv.style.display = 'block';
            }
            isValid = false;
        }

        // İlan Açıklaması kontrolü (boşsa default değer)
        const descriptionInput = document.getElementById('descriptionInput');
        if (!descriptionInput.value.trim()) {
            descriptionInput.value = 'İlan Açıklaması Eklenmedi';
        }

        // Tüm validasyonlar geçtiyse formu submit et
        if (isValid) {
            form.submit();
        } else {
            // İlk hataya scroll yap
            const firstError = document.querySelector('.is-invalid');
            if (firstError) {
                firstError.scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
        }
    });

    function showError(element, message) {
        element.classList.add('is-invalid');
        const errorDiv = element.parentElement.querySelector('.error-message');
        if (errorDiv) {
            errorDiv.textContent = message;
            errorDiv.style.display = 'block';
        }
    }

    function clearError(element) {
        element.classList.remove('is-invalid');
        const errorDiv = element.parentElement.querySelector('.error-message');
        if (errorDiv) {
            errorDiv.style.display = 'none';
            errorDiv.textContent = '';
        }
    }
});