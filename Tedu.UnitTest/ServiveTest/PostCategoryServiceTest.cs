using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TeduShop.Data.Repositories;
using TedShop.Data.Infrastructure;
using TeduShop.Service;
using TeduShop.Model.Models;

namespace Tedu.UnitTest.ServiveTest
{
    /// <summary>
    /// Summary description for PostCategoryServiceTest
    /// </summary>
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUntitOfWork;
        private PostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUntitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object,_mockUntitOfWork.Object);
            _listCategory = new List<PostCategory>() {
                new PostCategory(){ID = 1,Name ="Name_1",Status=true},
                 new PostCategory(){ID = 2,Name ="Name_2",Status=true},
                  new PostCategory(){ID = 3,Name ="Name_3",Status=true}
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            // goi phuong thuc
            var res = _categoryService.GetAll() as List<PostCategory>;

            // so sanh
            Assert.IsNotNull(res);
            Assert.AreEqual(3, res.Count);

        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test";
            category.Alias = "test";
            category.Status = true;
           
            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p)=>
            {
                p.ID = 1;
                return p; ;
            });
            var res = _categoryService.Add(category);

            Assert.IsNotNull(res);
            Assert.AreEqual(1, res.ID);
        }
    }
}
