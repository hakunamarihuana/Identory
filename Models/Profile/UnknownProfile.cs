using Newtonsoft.Json.Linq;

namespace Identory.Models.Profile
{
    public class UnknownProfile
    {
        /// <summary>
        /// Identory base profile. Contains most of the values. Can be casted to a more specific profile with <see cref="GetProfile{ProfileType}"/>
        /// </summary>
        public IdentoryProfile BaseProfile { get; private set; }
        /// <summary>
        /// Identory profile as a <see cref="JToken"/>. Can be used for custom casting.
        /// </summary>
        public JToken ParsedProfile { get; private set; }

        internal UnknownProfile(JToken parsedProfile)
        {
            this.ParsedProfile = parsedProfile;
            this.BaseProfile = parsedProfile.ToObject<IdentoryProfile>();
        }
        /// <summary>
        /// Cast to a specific profile.
        /// </summary>
        /// <typeparam name="ProfileType"></typeparam>
        /// <returns>Specific profile</returns>
        public ProfileType GetProfile<ProfileType>() where ProfileType : IdentoryProfile
        {
            return ParsedProfile.ToObject<ProfileType>();
        }
    }
}
