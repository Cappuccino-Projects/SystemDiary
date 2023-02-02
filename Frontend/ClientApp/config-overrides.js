const path = require('path');
const DirectoryNamedWebpackPlugin = require("directory-named-webpack-plugin");
const { alias } = require('react-app-rewire-alias');

module.exports = function override(config) {
  
  alias({
    '@Components': 'src/components', 
    '@Styles': 'src/styles', 
    '@Themes': 'src/styles/themes', 
    '@Pages': 'src/pages', 
    '@Contexts': 'src/contexts', 
    '@Fonts': 'src/fonts', 
    '@Layout': 'src/layouts', 
    '@Reducers': 'src/reducers',
    '@Hooks': 'src/hooks',
    '@Mixins': 'src/styles/mixins',
    '@Routes': 'src/routes',
    '@Widgets': 'src/widgets'
  })(config);

  return config;
}