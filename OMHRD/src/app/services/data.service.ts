import { EventEmitter, Injectable } from "@angular/core";
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class DataService {
    private cartValueSource = new BehaviorSubject(0);
    cartValue = this.cartValueSource.asObservable();

    private cartQtySource = new BehaviorSubject(0);
    cartQty = this.cartQtySource.asObservable();

    constructor() { }

    updateCartValue(value: number, qty: number) {
        this.cartValueSource.next(value);
        this.cartQtySource.next(qty);
    }

}