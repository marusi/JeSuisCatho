// SW Version

const version = '1.1';

//Static Cache - App Shell

const appAssets = [
  'index.html',
  'assets/js/jquery.min.js',
  'assets/js/bootstrap.min.js',
  'assets/js/app.js',
  'runtime.js',
  'polyfills.js',
  'styles.js',
  'vendor.js',

  'assets/css/winstrap.css',
  'styles.css'
]


// SW Install
self.addEventListener('install', e => {
  e.waitUntil(
    caches.open(`static-${version}`)
      .then(cache => cache.addAll(appAssets))
  );
});

// SW Activate
self.addEventListener('activate', e => {

  // Clean static cache
  let cleaned = caches.keys().then(keys => {
    keys.forEach(key => {
      if (key !== `static-${version}` && key.match('static-')) {
        return caches.delete(key);
      }
    });
  });
  //e.waitUntil(cleaned);
});


// Static cache startegy - Cache with Network Fallback
const staticCache = (req) => {

  return caches.match(req).then(cachedRes => {

    // Return cached response if found
    if (cachedRes) return cachedRes;

    // Fall back to network
    return fetch(req).then(networkRes => {

      // Update cache with new response
      caches.open(`static-${version}`)
        .then(cache => cache.put(req, networkRes));

      // Return Clone of Network Response
      return networkRes.clone();
    });
  });
};

// SW Fetch
self.addEventListener('fetch', e => {

  // App shell
  if (e.request.url.match(location.origin)) {
    e.respondWith(staticCache(e.request));
  }
});
