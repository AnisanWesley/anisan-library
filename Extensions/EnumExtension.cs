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
            return ((Direction)pos & (Direction)compared) != 0;
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
		
        //Sample
	public enum Direction
        {
            None = 0,      //0000
            Left = 1,      //0001
            Right = 1<<1,  //0010
            Up = 1<<2,     //0100
            Down = 1<<3,   //1000
        }



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
