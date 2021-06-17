var ExtractTextPlugin = require ("extract-text-webpack-plugin");
var path = require ("path");

var scssConfig = {
    mode: "production",
    entry: {
        green: "./R7.Epsilon/Skins/css/green-theme.scss",
        blue: "./R7.Epsilon/Skins/css/blue-theme.scss",
        brown: "./R7.Epsilon/Skins/css/brown-theme.scss",
        contrast: "./R7.Epsilon/Skins/css/contrast-theme.scss"
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
            filename: "[name]-theme.min.css",
            allChunks: true
        })
    ]
};

var jsConfig = {
    mode: "production",
    entry: {
        skin: "./R7.Epsilon/Skins/js/skin.js",
        shortList: "./R7.Epsilon/Skins/js/shortList.js"
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
