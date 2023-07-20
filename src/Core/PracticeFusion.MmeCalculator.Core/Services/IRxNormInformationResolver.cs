namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    ///     Resolves an RxNorm CUI into an RxNorm drug name
    /// </summary>
    public interface IRxNormInformationResolver
    {
        /// <summary>
        ///     Resolve the RxNorm CUI into an RxNorm drug name
        /// </summary>
        /// <param name="rxNormCui"></param>
        /// <returns></returns>
        string ResolveRxNormCode(string rxNormCui);
    }
}