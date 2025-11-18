// Customer JavaScript

// Update cart count
function updateCartCount() {
    fetch('/Cart?handler=GetCartCount')
        .then(response => response.json())
        .then(data => {
            document.getElementById('cart-count').textContent = data.count || 0;
        })
        .catch(error => console.error('Error fetching cart count:', error));
}

// Add to cart
function addToCart(variantId, quantity = 1) {
    fetch('/Cart?handler=AddToCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
        },
        body: JSON.stringify({ variantId, quantity })
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            showNotification('Đã thêm vào giỏ hàng', 'success');
            updateCartCount();
        } else {
            showNotification(data.message || 'Có lỗi xảy ra', 'error');
        }
    })
    .catch(error => {
        console.error('Error adding to cart:', error);
        showNotification('Có lỗi xảy ra', 'error');
    });
}

// Remove from cart
function removeFromCart(cartItemId) {
    if (!confirm('Bạn có chắc muốn xóa sản phẩm này?')) return;
    
    fetch('/Cart?handler=RemoveFromCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
        },
        body: JSON.stringify({ cartItemId })
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            location.reload();
        } else {
            showNotification(data.message || 'Có lỗi xảy ra', 'error');
        }
    })
    .catch(error => {
        console.error('Error removing from cart:', error);
        showNotification('Có lỗi xảy ra', 'error');
    });
}

// Update cart quantity
function updateCartQuantity(cartItemId, quantity) {
    if (quantity < 1) return;
    
    fetch('/Cart?handler=UpdateQuantity', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
        },
        body: JSON.stringify({ cartItemId, quantity })
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            location.reload();
        } else {
            showNotification(data.message || 'Có lỗi xảy ra', 'error');
        }
    })
    .catch(error => {
        console.error('Error updating quantity:', error);
        showNotification('Có lỗi xảy ra', 'error');
    });
}

// Show notification
function showNotification(message, type = 'info') {
    const alertClass = type === 'success' ? 'alert-success' : 
                      type === 'error' ? 'alert-danger' : 'alert-info';
    
    const alertHtml = `
        <div class="alert ${alertClass} alert-dismissible fade show notification-alert" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    `;
    
    const container = document.createElement('div');
    container.innerHTML = alertHtml;
    container.style.position = 'fixed';
    container.style.top = '20px';
    container.style.right = '20px';
    container.style.zIndex = '9999';
    
    document.body.appendChild(container);
    
    setTimeout(() => {
        container.remove();
    }, 5000);
}

// Filter products
function applyFilters() {
    const form = document.getElementById('filter-form');
    if (form) {
        form.submit();
    }
}

function resetFilters() {
    const form = document.getElementById('filter-form');
    if (form) {
        form.querySelectorAll('input[type="text"], input[type="number"]').forEach(input => {
            input.value = '';
        });
        form.querySelectorAll('input[type="checkbox"]').forEach(checkbox => {
            checkbox.checked = false;
        });
        form.querySelectorAll('select').forEach(select => {
            select.selectedIndex = 0;
        });
        form.submit();
    }
}

// Price range slider
function updatePriceRange() {
    const minPrice = document.getElementById('minPrice')?.value || 0;
    const maxPrice = document.getElementById('maxPrice')?.value || 0;
    const display = document.getElementById('priceRangeDisplay');
    
    if (display) {
        display.textContent = `${formatCurrency(minPrice)} - ${formatCurrency(maxPrice)}`;
    }
}

// Format currency
function formatCurrency(amount) {
    return new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND'
    }).format(amount);
}

// Initialize on page load
document.addEventListener('DOMContentLoaded', function() {
    // Update cart count
    if (document.getElementById('cart-count')) {
        updateCartCount();
    }
    
    // Setup quantity controls
    document.querySelectorAll('.quantity-minus').forEach(btn => {
        btn.addEventListener('click', function() {
            const input = this.nextElementSibling;
            const currentValue = parseInt(input.value);
            if (currentValue > 1) {
                input.value = currentValue - 1;
                const cartItemId = this.dataset.cartItemId;
                if (cartItemId) {
                    updateCartQuantity(cartItemId, currentValue - 1);
                }
            }
        });
    });
    
    document.querySelectorAll('.quantity-plus').forEach(btn => {
        btn.addEventListener('click', function() {
            const input = this.previousElementSibling;
            const currentValue = parseInt(input.value);
            const maxValue = parseInt(input.max) || 999;
            if (currentValue < maxValue) {
                input.value = currentValue + 1;
                const cartItemId = this.dataset.cartItemId;
                if (cartItemId) {
                    updateCartQuantity(cartItemId, currentValue + 1);
                }
            }
        });
    });
    
    // Setup color selection
    document.querySelectorAll('.color-option').forEach(option => {
        option.addEventListener('click', function() {
            document.querySelectorAll('.color-option').forEach(opt => opt.classList.remove('selected'));
            this.classList.add('selected');
        });
    });
    
    // Setup size selection
    document.querySelectorAll('.size-option').forEach(option => {
        option.addEventListener('click', function() {
            if (!this.classList.contains('disabled')) {
                document.querySelectorAll('.size-option').forEach(opt => opt.classList.remove('selected'));
                this.classList.add('selected');
            }
        });
    });
});
