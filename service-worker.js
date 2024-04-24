// Caution! Be sure you understand the caveats before publishing an application with
// offline support. See https://aka.ms/blazor-offline-considerations

self.importScripts('./service-worker-assets.js');
self.addEventListener('fetch', event => event.respondWith(fetch(event.request)));/* Manifest version: TRJYN9Ux */
