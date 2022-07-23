var fs = require('fs')
var Nuxt = require('nuxt')
var resolve = require('path').resolve

var rootDir = resolve('.')
var nuxtConfigFile = resolve(rootDir, 'nuxt.config.js')

var options = {}
if (fs.existsSync(nuxtConfigFile)) {
  options = require(nuxtConfigFile)
}
if (typeof options.rootDir !== 'string') {
  options.rootDir = rootDir
}
options.dev = false // Force production mode (no webpack middleware called)

var nuxt = new Nuxt(options)

new nuxt.Server(nuxt)
  .listen(
    process.env.PORT || process.env.npm_package_config_nuxt_port,
    process.env.HOST || process.env.npm_package_config_nuxt_host
)