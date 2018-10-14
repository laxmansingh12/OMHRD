
export class CartItemDTO{
   public Id:number;
   public UserId: number;
   public ProductId: number;
   public ProductName: string;
   public SizeId: number;
   public ColorId: number;
   public Quantity: number;
   public Discount: number;
   public DiscountedPrice: number;
   public IsQuantityForAddition: boolean;
};