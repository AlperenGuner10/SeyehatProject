﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.Areas.Admin.Models;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager=roleManager;
			_userManager=userManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
		{
			AppRole appRole = new AppRole()
			{
				Name = createRoleViewModel.RoleName
			};
			var result = await _roleManager.CreateAsync(appRole);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
		public async Task<IActionResult> DeleteRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			UpdateRoleViewModel model = new UpdateRoleViewModel()
			{
				RoleId = value.Id,
				RoleName = value.Name
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleId);
			value.Name = model.RoleName;
			await _roleManager.UpdateAsync(value);
			return RedirectToAction("Index");
		}
		public IActionResult UserList()
		{
			var values = _userManager.Users.ToList();	
			return View(values);
		}
		[HttpGet]
		public async Task<IActionResult> AssignRole(int id)
		{
			var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
			TempData["Userid"] = user.Id;
			var roles = _roleManager.Roles.ToList();
			var userRoles = await _userManager.GetRolesAsync(user);
			List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
			foreach (var item in roles)
			{
				RoleAssignViewModel model = new RoleAssignViewModel();
				model.RoleId = item.Id;
				model.RoleName = item.Name;
				model.RoleExist = userRoles.Contains(item.Name);
				roleAssignViewModels.Add(model);
			}
			return View(roleAssignViewModels);
		}
		[HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModels)
		{
			var userid =(int)TempData["Userid"];
			var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
			foreach (var item in roleAssignViewModels)
			{
				if (item.RoleExist)
				{
					await _userManager.AddToRoleAsync(user,item.RoleName);
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.RoleName);
				}
			}
			return RedirectToAction("UserList");
		}
	}
}
