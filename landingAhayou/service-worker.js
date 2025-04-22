const CACHE_NAME = 'pwa-cache-v1';
const urlsToCache = [
    'https://www.bbr.com.bo/landingTest/home.aspx',
    'manifest.json',
    'icon-192x192.png',
    'icon-512x512.png'
];

// Install the service worker
self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open(CACHE_NAME)
            .then((cache) => {
                return cache.addAll(urlsToCache);
            })
    );
});

// Fetch resources from the cache
self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request)
            .then((response) => {
                return response || fetch(event.request);
            })
    );
});
