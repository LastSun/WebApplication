/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    // load Grunt plugins from NPM
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    // configure plugins
    grunt.initConfig({
        uglify: {
            my_target: {
                files: { 'wwwroot/app.min.js': ['app/*.js', 'app/**/*.js'] }
            },
            angular_multiselect: {
                files: { 'bower_components/amitava82-angular-multiselect/src/multiselect-tpls.min.js': ['bower_components/amitava82-angular-multiselect/src/multiselect-tpls.js'] }
            }
        },

        watch: {
            scripts: {
                files: ['app/*.js', 'app/**/*.js'],
                tasks: ['uglify']
            }
        },

        copy: {
            main: {
                files: [
                    { expand: true, cwd: 'bower_components', flatten: true, src: ['bootstrap/dist/css/*.css'], dest: 'wwwroot/lib/css/' },
                    { expand: true, cwd: 'bower_components', flatten: true, src: ['**/*.min.js', '!**/jquery*', '!**/sizzle*', '!**/bootstrap*.js', '!**/ui-bootstrap.min.js', '!**/respond.matchmedia.addListener.min.js'], dest: 'wwwroot/lib/js/' },
                ]
            }
        },

        clean: {
            build: ['wwwroot'],
            release:[]
        }
    });

    // define tasks
    grunt.registerTask('default', ['uglify', 'watch']);
    grunt.registerTask('build', ['clean', 'copy']);
};