import { ProductPriceDTO } from '../models/ProductPriceDTO';

export class ProductDTO{
   public Id:number;
   public Code:string;
   public Name:string;
   public HSN:string;
   public ShortDescription:string;
   public Description:string;
   public SizeList:Array<string>;
   public ColorList:Array<string>;
   public PriceList:Array<ProductPriceDTO>;
};