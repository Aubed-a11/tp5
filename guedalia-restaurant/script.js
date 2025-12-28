function reservation() {
  const name = document.getElementById('name').value;
  const phone = document.getElementById('phone').value;
  const date = document.getElementById('date').value;
  const time = document.getElementById('time').value;
  const people = document.getElementById('people').value;

  const message = `Bonjour, je souhaite réserver au restaurant Guédalia :\nNom: ${name}\nTéléphone: ${phone}\nDate: ${date}\nHeure: ${time}\nNombre de personnes: ${people}`;
  const url = `https://wa.me/229XXXXXXXX?text=${encodeURIComponent(message)}`;
  window.open(url, '_blank');
  return false;
}
let panier = [];
let total = 0;

// Ajouter un produit au panier
function ajouterAuPanier(nom, prix) {
  panier.push({nom, prix});
  total += prix;
  afficherPanier();
  // Effet visuel
  const panierSection = document.getElementById('panier');
  panierSection.style.transform = 'scale(1.05)';
  setTimeout(() => panierSection.style.transform = 'scale(1)', 200);
}

// Afficher le panier
function afficherPanier() {
  const liste = document.getElementById('listePanier');
  liste.innerHTML = '';
  panier.forEach((item, index) => {
    const li = document.createElement('li');
    li.textContent = `${item.nom} - ${item.prix} FCFA`;
    // Effet hover dynamique
    li.addEventListener('mouseenter', () => li.style.color = '#ffb347');
    li.addEventListener('mouseleave', () => li.style.color = '#fff');
    liste.appendChild(li);
  });
  document.getElementById('total').textContent = total;
}

// Paiement Mobile Money via WhatsApp
document.getElementById('payer').addEventListener('click', () => {
  if(panier.length === 0){
    alert('Votre panier est vide !');
    return;
  }
  let message = "Bonjour, je souhaite commander :\n";
  panier.forEach(item => message += `${item.nom} - ${item.prix} FCFA\n`);
  message += `Total à payer : ${total} FCFA\nJ'ai payé via Mobile Money.`;

  const numeroWhatsApp = '229XXXXXXXX';
  const url = `https://wa.me/${numeroWhatsApp}?text=${encodeURIComponent(message)}`;
  window.open(url, '_blank');
});

// Animation de fond dynamique
const hero = document.querySelector('.hero');
let hue = 0;
setInterval(() => {
  hue += 1;
  hero.style.background = `linear-gradient(135deg, hsl(${hue}, 100%, 50%), hsl(${(hue+60)%360}, 60%, 35%))`;
}, 100);
// ===== Animation au scroll =====
const sections = document.querySelectorAll('section');

window.addEventListener('scroll', () => {
  const scrollPos = window.scrollY + window.innerHeight * 0.75;

  sections.forEach(section => {
    if(scrollPos > section.offsetTop){
      section.style.transform = 'translateY(0)';
      section.style.opacity = 1;
    }
  });
});

// ===== Boutons Mobile Money =====
const btnMM = document.querySelector('.btn-whatsapp');
btnMM.addEventListener('mouseenter', () => {
  btnMM.style.background = 'linear-gradient(45deg, #ffb347, #ff6b35)';
  btnMM.style.transform = 'scale(1.1) rotate(-3deg)';
});
btnMM.addEventListener('mouseleave', () => {
  btnMM.style.background = '#ffb347';
  btnMM.style.transform = 'scale(1) rotate(0deg)';
});

// ===== Formulaire réservation =====
function reservation() {
  alert('Merci pour votre réservation ! Nous vous contacterons bientôt.');
  return false; // Empêche le reload
}

// ===== Fond animé dégradé =====
let hue = 0;
setInterval(() => {
  hue += 1;
  sections.forEach(sec => {
    sec.style.background = `linear-gradient(135deg, hsl(${hue}, 100%, 50%), hsl(${(hue+60)%360}, 60%, 35%))`;
  });
}, 100);
