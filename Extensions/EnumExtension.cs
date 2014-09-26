namespace Extensions
{
	public class EnumExtensions
	{
        /// <summary>
        /// Checks if bitwise enum is from value compared
        /// Verifica se a flag de enum contém o valor comparado
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="compared"></param>
        /// <returns></returns>
		public static bool IsBitwise(this Enum pos, Enum compared)
        {
            return ((Extensive)pos & (Extensive)compared) != 0;
        }
        /// <summary>
        /// Checks if bitwise enum is not from value compared
        /// Verifica se a flag de enum não contém o valor comparado
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="compared"></param>
        /// <returns></returns>
        public static bool IsNotBitwise(this Enum pos, Enum compared)
        {
            return !pos.IsBitwise(compared);
        }
		
        //Replace this for any enum
		public enum Extensive{q,w,e,r,t,y,u,i,o,p,a,s,d,f,g,h,j,k,l,z,x,c,v,b,n,m}



        /// <summary>
        /// Returns enums description
        /// Retorna a descrição do enum
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string Description(this Enum e)
        {
            var type = e.GetType();
            var field = type.GetField(e.ToString());
            var attribute = field.GetCustomAttributes(false).SingleOrDefault() as DescriptionAttribute;
            return attribute != null ? attribute.Description : string.Empty;
        }
	}
}