const gulp = require("gulp");
var sass = require('gulp-sass')(require('sass'));
const sourcemaps = require("gulp-sourcemaps");
const postcss = require("gulp-postcss");
const autoprefixer = require("autoprefixer");
const cssnano = require("cssnano");
const terser = require("gulp-terser");
const rename = require("gulp-rename");


function styles() {

    return(
        gulp.src("wwwroot/css/*.scss")
            .pipe(sourcemaps.init())
            .pipe(sass())
            .pipe(postcss([autoprefixer({grid:true}), cssnano()]))
            .pipe(sourcemaps.write("."))
            .pipe(gulp.dest("wwwroot/css"))
    );

}

function js() {

    return(
        gulp.src(["wwwroot/js/*.js", "!wwwroot/js/*min.js"])
            .pipe(terser())
            .pipe(rename({
                suffix:".min"
            }))
            .pipe(gulp.dest("wwwroot/js"))
    );

}

function watch(){
    gulp.watch("wwwroot/css/*.scss", styles);
    gulp.watch(["wwwroot/js/*.js", "!wwwroot/js/*min.js"], js);
}

const build = gulp.parallel(styles, js);

exports.styles = styles;
exports.js = js;
exports.watch = watch;
exports.build = build;