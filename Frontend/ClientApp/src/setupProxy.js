const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://26.105.105.194:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://26.105.105.194:39126';

const context =  [
  "/api",
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    changeOrigin: true,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
