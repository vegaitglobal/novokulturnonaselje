NOTE: if you have node.js and gulp installed, skip to step 4.

1. Download and install node.js https://nodejs.org/en/download/
2. Run node.js command prompt
3. Install gulp globally - "npm install gulp -g"
4. Next run "npm install" to collect all gulp dependencies
5. To compile styles/svgs run "gulp"
6. If svg sprite is not created, run command "gulp sprite" command before step 5.

/***** ICON FONT *****/
Icon font: to generate new icons and create font, run "gulp iconfont" command.
In order to show icons, all you need to do is add html "<i class="font-ico-heart"></i>"
NOTE: There are some default styles (in typography.scss) made for this demo, please adjust them for your project.

/***** package.json *****/
NOTE: if package.json is empty or not updating, run "npm init" command.

/***** Node modules remove *****/
Removing node_modules folder from the project in Windows is almost impossible,
but you can use SHIFT + DELETE in Total Commander.

We would recommend using rimraf plugin. Type "npm install rimraf -g".
Navigate to the project folder, type "rimraf node_modules" to remove node_modules.

/***** Node.js update *****/
1. Uninstall previous version and close all open terminals
2. Install new version
3. Open terminal and type "npm cache clean"
4. Then run "npm install"

NOTE: If you get error message in compiling project with installed node modules, please remove node_modules folder and install dependencies again. Reason is that dependencies are connected to old Node.js instance.

/***** Editor config *****/
EditorConfig helps developers define and maintain consistent coding styles between different editors and IDEs - more info - http://editorconfig.org/

Editors like Atom and Sublime must install plugins to read this. Most IDE's have it already.
Atom - https://atom.io/packages/editorconfig
Sublime - https://github.com/sindresorhus/editorconfig-sublime
