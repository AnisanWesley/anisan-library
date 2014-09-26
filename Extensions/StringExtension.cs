using System.Text;

namespace Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Remove all accentuation from text
        /// Remove toda a acentuação do texto
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
	     static string Desaccent(this String text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        /// <summary>
        /// Checks if the text contains the query without worrying about format of text and blank spaces
        /// Verifica se o texto contém a consulta sem se preocupar com o formato de texto e espaços em branco
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        /// <returns></returns>
         public static bool Query(this string obj, string query)
         {
             return Desaccent(obj.ToString().ToLower().Trim()).Contains(query.ToString().ToLower().Trim());
         }
         /// <summary>
         /// Checks if the text is null, empty or a blank space
         /// Verifica se o texto é nulo, vazio ou contêm espaços em branco
         /// </summary>
         public static class StringExtension
         {
             public static bool IsEmpty(this string text)
             {
                 return String.IsNullOrWhiteSpace(text);
             }
         }

        


    }


}

