export class LogoApiService {
    getUrlToLogo(src) {
        return `https://logo.clearbit.com/${new URL(src).host}`;
    }
}