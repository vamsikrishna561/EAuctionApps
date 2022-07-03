using E_Auction.Application.Interfaces;
using E_Auction.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class GetBidListQuery : IQuery<List<BuyerDto>>
    {
        public string EnrolledIn { get; }
        public int? NumberOfCourses { get; }

        public GetBidListQuery(string enrolledIn, int? numberOfCourses)
        {
            EnrolledIn = enrolledIn;
            NumberOfCourses = numberOfCourses;
        }

        internal sealed class GetListQueryHandler : IQueryHandler<GetBidListQuery, List<BuyerDto>>
        {

            private readonly ISellerRepository _sellerRepository;
            public GetListQueryHandler(ISellerRepository sellerRepository)
            {
                _sellerRepository = sellerRepository;
            }

            public List<BuyerDto> Handle(GetBidListQuery query)
            {
                return null;
                //string sql = @"
                //    SELECT s.StudentID Id, s.Name, s.Email,
	               //     s.FirstCourseName Course1, s.FirstCourseCredits Course1Credits, s.FirstCourseGrade Course1Grade,
	               //     s.SecondCourseName Course2, s.SecondCourseCredits Course2Credits, s.SecondCourseGrade Course2Grade
                //    FROM dbo.Student s
                //    WHERE (s.FirstCourseName = @Course
		              //      OR s.SecondCourseName = @Course
		              //      OR @Course IS NULL)
                //        AND (s.NumberOfEnrollments = @Number
                //            OR @Number IS NULL)
                //    ORDER BY s.StudentID ASC";

                //using (SqlConnection connection = new SqlConnection(_connectionString.Value))
                //{
                //    List<StudentDto> students = connection
                //        .Query<StudentDto>(sql, new
                //        {
                //            Course = query.EnrolledIn,
                //            Number = query.NumberOfCourses
                //        })
                //        .ToList();

                //    return students;
                //}
            }
        }
    }
}
