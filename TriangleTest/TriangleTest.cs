using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assingment02;

namespace TriangleTest
{
    [TestFixture]
    public class TriangleTest
    {
        
        [Test(Description = "This test case is created to check the method should throw exception for all the invalid range of inputs. In this test data is provides as 10,-15.1,10 with negative value. The method should directly bypass the control out as it throw exception Argument out of Range as geometry cannot be created with the negative length(Scaler plane).")]
        public void Setting_negative_value_for_second_Side()
        {
            //ARRANGE
            double firstSide = 10.0, secondSide = -15.01,  thirdSide=10;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide,secondSide,thirdSide);
            //ASSERT
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => tri.Analyze());
            Assert.That(ex.Message.Contains("Invalid length to form triangle"));

        }
        [Test(Description = "This test case is created to check the method should throw exception for all the invalid range of inputs. In this test data is provides as 0,10,10. The method should directly bypass the control out as it throw exception Argument out of Range.")]
        public void Setting_zero_values_for_one_sides()
        {
            //ARRANGE
            double firstSide = 0, secondSide = 10, thirdSide = 10;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => tri.Analyze());
            Assert.That(ex.Message.Contains("Invalid length to form triangle"));

        }

        [Test(Description = "This test case will check the triangle formed is an Isosceles triangle as it satisfy the the condition to form a triangle and having two same length sides")]
        public void Checking_Isosceles_triangle()
        {
            //ARRANGE
            double firstSide = 10.0, secondSide = 1, thirdSide = 10;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            
           Assert.That(tri.Analyze(),Does.Contain("Isosceles Triangle"));

        }
        
     
        [Test(Description = "This test case will check that the triangle form is Equilateral on providing the same values for all three sides.")]
        public void Checking_Equilateral_triangle()
        {
            //ARRANGE
            double firstSide = 10, secondSide = 10.0, thirdSide = 10;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.AreEqual("Equilateral Triangle", tri.Analyze());

        }
       
      
        [Test(Description = "Keeping in check that the set value for th ethird side should be greater than the difference between two side. this test case will check if the third side is set to value less than 4 that is 10-6 then then it should not form a triangle.")]
        public void Setting_length_less_than_differnece_between_two_sides()
        {
            //ARRANGE
            double firstSide = 6, secondSide = 10, thirdSide = 3.9;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.That(tri.Analyze(), Does.Contain("Does not from any triangle"));

        }
        [Test(Description = "Setting value of the thirdSide = 4 that means the third side can be set either the shortest or the longest. To check firstSide + thirdSide > SecondSide, if we keep 6+4 > 10 it is not correct, the value of the thirdSide should be greater than 4. It can be 4.01, basically keep check that the thirsdside should range in 10-6 value. this test case will check the condition that the value of thirs dhould not be equal to the 10-6.")]
        public void Setting_length_equals_to_differnece_between_two_sides()
        {
            //ARRANGE
            double firstSide = 6, secondSide = 10, thirdSide = 4;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.That(tri.Analyze(), Does.Contain("Does not from any triangle"));

        }
        [Test(Description = "With the values 6,10,4.1 the triangle formed is a Scalene triangle as it satisfies 6+10>4.1, 6+4.1>10 10+4.1> 6. All three condition therefore the control goes to the else statement checking the type of triangle formed. This test case will check the Scalene triangle should be formed on providing the three different values as per the constrains.")]
        public void Setting_length_Greater_than_differnece_between_two_sides()
        {
            //ARRANGE
            double firstSide = 6, secondSide = 10, thirdSide = 4.1;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.AreEqual("Scalene Triangle", tri.Analyze());

        }
        [Test(Description = "As per the rule the firstside + secondSide > thirdSide and with the values 6,10,16.1 the statement is not getting satisfied as 16 is not greater than 16.1. When the check is made in Analyze method the control falls into the if statement that states with this value triangle cannot be created.")]
        public void Setting_length_greater_than_sum_of_two_sides()
        {
            //ARRANGE
            double firstSide = 6, secondSide = 10, thirdSide = 16.1;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.That(tri.Analyze(), Does.Contain("Does not from any triangle"));

        }
        [Test(Description = "As per the rule firstSide + secondSide > thirdSide this means that it falls under the triangle inequality theorem. Neither the third side can be greater than 16 nor it can be equal to 16. On setting the values to 6,10,16 the triangle is analyzed as Invalid (satisfying If condition). This test case will check the triangle is not being formed when the third side is set equal to the sum of first and second side. That is 6 + 10 >16 condition is not satisfied.")]
        public void Setting_length_equals_to_sum_of_two_sides()
        {
            //ARRANGE
            double firstSide = 6, secondSide = 10, thirdSide =16;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.That(tri.Analyze(), Does.Contain("Does not from any triangle"));

        }
        [Test(Description = "As per the rule firstSide + secondSide > thirdSide, the value set are 6,10,15.9 that means 6 + 10 > 15.9. If condition is not satisfied and the control moved to else statement stating the triangle formed is Scalene")]
        public void Setting_length_lesser_than_sum_of_two_sides()
        {
            //ARRANGE
            double firstSide = 6, secondSide = 10, thirdSide = 15.9;
            //ACT
            TriangleSolver tri = new TriangleSolver(firstSide, secondSide, thirdSide);
            //ASSERT
            Assert.AreEqual("Scalene Triangle", tri.Analyze());

        }
    }
}
