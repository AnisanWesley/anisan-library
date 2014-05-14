namespace Extensions
{
	public class EnumExtensions
	{
		public static bool IsBitwise(this Enum pos, Enum comparer)
        {
            return ((Extensive)pos & (Extensive)comparer) != 0;
        }
        public static bool IsNotBitwise(this Enum pos, Enum comparer)
        {
            return !pos.IsBitwise(comparer);
        }
		
		public enum Extensive{q,w,e,r,t,y,u,i,o,p,a,s,d,f,g,h,j,k,l,z,x,c,v,b,n,m}
	}
}