document.addEventListener('DOMContentLoaded', () => {
    // Mobile menu toggle
    const menuButton = document.getElementById('mobile-menu');
    const menu = document.getElementById('nav-menu');
    
    menuButton.addEventListener('click', () => {
        menu.classList.toggle('hidden');
    });

    // Login modal handling
    const loginModal = document.getElementById('login-modal');
    document.querySelectorAll('[data-modal-toggle]').forEach(button => {
        button.addEventListener('click', () => {
            loginModal.classList.toggle('hidden');
        });
    });

    // Event registration handling
    document.querySelectorAll('.event-register').forEach(button => {
        button.addEventListener('click', async (e) => {
            const eventId = e.target.dataset.eventId;
            try {
                const response = await fetch(`/Event/Register/${eventId}`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                
                if (response.ok) {
                    window.location.reload();
                }
            } catch (error) {
                console.error('Registration failed:', error);
            }
        });
    });
});