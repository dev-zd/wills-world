async function handleAuth(event, action) {
    event.preventDefault();

    let formData;
    if (event.target.tagName === 'FORM') {
        formData = new FormData(event.target);
    } else {
        formData = new FormData();
    }

    formData.append('action', action);

    try {
        const response = await fetch('api.php', {
            method: 'POST',
            body: formData
        });
        const data = await response.json();

        if (data.success) {
            if (action === 'logout') {
                window.location.href = 'login.php';
            } else {
                window.location.href = 'index.php';
            }
        } else {
            alert(data.message || 'An error occurred');
        }
    } catch (e) {
        console.error(e);
        alert('Connection error');
    }
}

function toggleMenu() {
    const dropdown = document.getElementById('userDropdown');
    dropdown.classList.toggle('show');
}

function launchGame() {
    const bubble = document.querySelector('.launch-bubble');
    bubble.style.animation = 'none';
    bubble.innerHTML = 'Launching...';

    // Trigger the custom protocol
    setTimeout(() => {
        window.location.href = 'willsworld://run';

        // Reset UI after delay
        setTimeout(() => {
            bubble.innerHTML = 'Launch Game';
            bubble.style.animation = 'pulse 2s infinite';
        }, 3000);
    }, 1000);
}

// Global click to close dropdown
window.onclick = function (event) {
    if (!event.target.matches('.user-icon') && !event.target.matches('.user-icon *')) {
        const dropdown = document.getElementById('userDropdown');
        if (dropdown && dropdown.classList.contains('show')) {
            dropdown.classList.remove('show');
        }
    }
}
