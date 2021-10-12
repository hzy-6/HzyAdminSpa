const path = require('path')

// vue.config.js for less-loader@6.0.0
module.exports = {
    //静态文件地址前缀
    publicPath: process.env.NODE_ENV == "production" ? "/client" : "/",
    devServer: {
        // development server port 8000
        port: 6877,
        // proxy: {
        //     '/admin': {
        //         target: 'http://localhost:6789/admin',
        //         ws: false,
        //         changeOrigin: true
        //     }
        // }
    },
    pages: {
        index: {
            // page 的入口
            entry: 'src/main.js',
            // 模板来源
            template: 'public/index.html',
            // 在 dist/index.html 的输出
            filename: 'index.html',
            // 当使用 title 选项时，
            // template 中的 title 标签需要是 <title><%= htmlWebpackPlugin.options.title %></title>
            title: 'HzyAdminSpa',
        },
    },
    css: {
        loaderOptions: {
            less: {
                lessOptions: {
                    modifyVars: {
                        // 'primary-color': '#1DA57A',
                        // 'link-color': '#1DA57A',
                        // 'border-radius-base': '2px',
                    },
                    javascriptEnabled: true,
                },
            },
        },
    },
    configureWebpack: config => {
        Object.assign(config, {
            resolve: {
                extensions: ['.js', '.json', '.vue', '.scss', '.css', '.less'],
                alias: {
                    '@': path.resolve('src'),
                }
            }

        })
    }
};

