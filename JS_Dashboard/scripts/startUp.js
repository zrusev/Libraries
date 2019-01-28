$(function start() {
    generator.empty('#footerDiv');
    
    generator.load('body', constants.body);
    
    welcomeService();
})