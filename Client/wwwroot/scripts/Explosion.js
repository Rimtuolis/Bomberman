function Explosion() {
    // Replace 'path/to/your/style.css' with your actual CSS file path
    var link = document.createElement('link');
    link.rel = 'stylesheet';
    link.type = 'text/css';
    link.href = '/css/explosion.css';
    document.head.appendChild(link);
}