using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.DTOs.Company;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Domain;
using Riok.Mapperly.Abstractions;

namespace HireManagement.Application.Mappings
{
    /// <summary>
    /// Compile-time generated mappings between domain entities and DTOs.
    /// Entity → DTO mappings must fill every DTO member; DTO → entity mappings must use every DTO member.
    /// </summary>
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public static partial class DtoMapper
    {
        #region AdminApi
        public static partial AdminApiDto? ToDto(this AdminApi? source);
        public static partial AdminApiListDto ToListDto(this AdminApi source);
        public static partial List<AdminApiListDto> ToListDtos(this IEnumerable<AdminApi> source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(CreateAdminApiDto.Password))]
        public static partial AdminApi ToEntity(this CreateAdminApiDto source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(UpdateAdminApiDto.Id))]
        public static partial void ApplyTo(this UpdateAdminApiDto source, AdminApi target);
        #endregion

        #region Candidate
        public static partial CandidateDto? ToDto(this Candidate? source);
        public static partial CandidateListDto ToListDto(this Candidate source);
        public static partial List<CandidateListDto> ToListDtos(this IEnumerable<Candidate> source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(CreateCandidateDto.Password))]
        public static partial Candidate ToEntity(this CreateCandidateDto source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(UpdateCandidateDto.Id))]
        public static partial void ApplyTo(this UpdateCandidateDto source, Candidate target);
        #endregion

        #region Company
        public static partial CompanyDto? ToDto(this Company? source);
        public static partial CompanyListDto ToListDto(this Company source);
        public static partial List<CompanyListDto> ToListDtos(this IEnumerable<Company> source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        public static partial Company ToEntity(this CreateCompanyDto source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(UpdateCompanyDto.Id))]
        public static partial void ApplyTo(this UpdateCompanyDto source, Company target);
        #endregion

        #region CompanyEmployee
        public static partial CompanyEmployeeDto? ToDto(this CompanyEmployee? source);
        public static partial CompanyEmployeeListDto ToListDto(this CompanyEmployee source);
        public static partial List<CompanyEmployeeListDto> ToListDtos(this IEnumerable<CompanyEmployee> source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(CreateCompanyEmployeeDto.Password))]
        public static partial CompanyEmployee ToEntity(this CreateCompanyEmployeeDto source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(UpdateCompanyEmployeeDto.Id))]
        public static partial void ApplyTo(this UpdateCompanyEmployeeDto source, CompanyEmployee target);
        #endregion

        #region Opening
        public static partial OpeningDto? ToDto(this Opening? source);
        public static partial OpeningListDto ToListDto(this Opening source);
        public static partial List<OpeningListDto> ToListDtos(this IEnumerable<Opening> source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        public static partial Opening ToEntity(this CreateOpeningDto source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(UpdateOpeningDto.Id))]
        public static partial void ApplyTo(this UpdateOpeningDto source, Opening target);
        #endregion

        #region OpeningApplication
        public static partial OpeningApplicationDto? ToDto(this OpeningApplication? source);
        public static partial OpeningApplicationListDto ToListDto(this OpeningApplication source);
        public static partial List<OpeningApplicationListDto> ToListDtos(this IEnumerable<OpeningApplication> source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        public static partial OpeningApplication ToEntity(this CreateOpeningApplicationDto source);

        [MapperRequiredMapping(RequiredMappingStrategy.Source)]
        [MapperIgnoreSource(nameof(UpdateOpeningApplicationDto.Id))]
        public static partial void ApplyTo(this UpdateOpeningApplicationDto source, OpeningApplication target);
        #endregion
    }
}
