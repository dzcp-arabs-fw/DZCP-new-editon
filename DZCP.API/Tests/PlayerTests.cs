using System.Runtime.InteropServices;
using Xunit;
using DZCP.API.Models;
using DZCP.API.Extensions;
using DZCP.Permissions;
using UnityEngine.Assertions;
using Assert = Xunit.Assert;

namespace DZCP.API.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void IsAdmin_WhenPlayerHasAdminPermission_ReturnsTrue()
        {
            // Arrange
            var player = new Player { UserId = "admin123" };
            PermissionManager.AddPermissionAsync(player.UserId, "dzcp.admin");
            
            // Act
            var result = player.IsAdmin();
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryGetItemInHand_WhenPlayerHasItem_ReturnsTrue()
        {
            // Arrange
            var player = new Player { CurrentItem = new Item() };
            
            // Act
            var result = player.TryGetItemInHand(out var item);
            
            // Assert
            Assert.True(result);
            Assert.NotNull(item);
        }
    }
}