const CACHE_NAME = 'pwa-cache-v10';
const urlsToCache = [
    'https://ahayouwebadmin-gmcscyb9f7g4frd9.mexicocentral-01.azurewebsites.net/Dashboard.aspx',
    'manifestadmin.json',
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
