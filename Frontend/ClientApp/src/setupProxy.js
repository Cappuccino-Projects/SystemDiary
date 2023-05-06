const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = env.API_PORT ? `https://127.0.0.1:${env.PORT}` :
  env.REACT_APP_API_ADDRESS ? env.REACT_APP_API_ADDRESS : 'http://127.0.0.1:7468';

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
