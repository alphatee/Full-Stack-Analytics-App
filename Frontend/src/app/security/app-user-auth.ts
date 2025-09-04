import { UserAuthBase } from "../shared/security/user-auth-base";

export class AppUserAuth extends UserAuthBase {
    canAccessProducts: boolean = false; 
    canAccessCategories: boolean = false;
    canAccessLogs: boolean = false;
    canAccessSettings: boolean = false;
    canAccessTravelDetails: boolean = false;
    canAddProduct: boolean = false;
    canEditProduct: boolean = false;
    canDeleteProduct: boolean = false;

    override init(): void {
        super.init(); // goes to user-auth-base class and runs it init()

        // then this below gets init to a start value
        this.canAccessProducts = false; 
        this.canAccessCategories = false;
        this.canAccessLogs = false;
        this.canAccessSettings = false; 
        this.canAccessTravelDetails = false;
        this.canAddProduct = false; 
        this.canEditProduct = false;
        this.canDeleteProduct = false;
    }

    getValueOfProperty(obj: any, key:string):boolean {
        let ret = obj[key]; // let ret = securityObject.CanAccessProducts; // this is equivalent
        return ret;
    }
}