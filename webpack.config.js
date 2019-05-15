var ExtractTextPlugin = require ("extract-text-webpack-plugin");
var path = require ("path");

var scssConfig = {
    mode: "production",
    entry: {
        default: "./R7.Epsilon/Skins/css/default-skin.scss",
        a11y: "./R7.Epsilon/Skins/css/a11y-skin.scss",
        consulting: "./R7.Epsilon/Skins/css/consulting-skin.scss",
        world: "./R7.Epsilon/Skins/css/world-skin.scss"
    },
    output: {
        // TODO: suppress JS output somehow?
        path: path.resolve (__dirname, "R7.Epsilon/Skins/css"),
        filename: ".webpack/[name].js"
    },
    module: {
        rules: [
            {
                test: /\.scss$/,
                exclude: /(node_modules|bower_components)/,
                use: ExtractTextPlugin.extract ({
                    use: [{
                        loader: "css-loader",
                        options: {url: false}
                    },
                    "sass-loader"]
                })
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin ({
            filename: "[name]-skin.min.css",
            allChunks: true
        })
    ]
};

var jsConfig = {
    mode: "production",
    entry: {
        skin: "./R7.Epsilon/Skins/js/skin.js",
        menu: "./R7.Epsilon/Skins/js/menu.js",
        feedback: "./R7.Epsilon/Skins/js/feedback.js"
    },
    output: {
        // TODO: suppress JS output somehow?
        path: path.resolve (__dirname, "R7.Epsilon/Skins/js"),
        filename: "[name].min.js"
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules|bower_components)/,
                use: {
                    loader: "babel-loader",
                    options: {
                        presets: ["@babel/preset-env"]
                    }
                }
            }
        ]
    },
};

module.exports = [scssConfig, jsConfig];
