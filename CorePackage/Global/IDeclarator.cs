﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Global
{
    /// <summary>
    /// Enumeration that represents the access level of a declaration
    /// </summary>
    public enum AccessMode
    {
        INTERNAL,
        EXTERNAL
    };

    /// <summary>
    /// Interface that defines actions linked to declarator behaviour
    /// </summary>
    /// <typeparam name="definitionType">Type of the definition the declarator is in charge of</typeparam>
    public interface IDeclarator<definitionType>
    {
        /// <summary>
        /// Will set a declaration of the given entity through the given name inside the declarator
        /// </summary>
        /// <param name="entity">Entity to declare</param>
        /// <param name="name">Declaration name</param>
        /// <param name="visibility">Declaration visibility</param>
        /// <returns>Given entity (usefull if you inherit many times of this interface)</returns>
        definitionType Declare(definitionType entity, string name, AccessMode visibility);

        /// <summary>
        /// Will remove and return the entity of the given name
        /// </summary>
        /// <param name="name">Declaration name</param>
        /// <returns>Poped entity</returns>
        definitionType Pop(string name);

        /// <summary>
        /// Allow to find an entity from it's name and visibility
        /// </summary>
        /// <param name="name">Name of the entity to find</param>
        /// <param name="visibility">Visbility of the entity to find</param>
        /// <returns>Found entity</returns>
        definitionType Find(string name, AccessMode visibility);

        /// <summary>
        /// Rename a entity in the declarator
        /// </summary>
        /// <param name="lastName">Current declaration name of the entity</param>
        /// <param name="newName">New name for the entity</param>
        /// <returns>Entity renamed</returns>
        definitionType Rename(string lastName, string newName);

        /// <summary>
        /// Allow to get the visibility of a declaration
        /// </summary>
        /// <param name="name">Name of the declaration to get</param>
        /// <param name="visibility">Visibility in which it will be stored</param>
        /// <returns>Entity</returns>
        definitionType GetVisibilityOf(string name, ref AccessMode visibility);

        /// <summary>
        /// Allow to change a declaration visibility into its contrary
        /// </summary>
        /// <param name="name">Name of the declaration</param>
        /// <param name="newVisibility">New visibility of the declaration</param>
        /// <returns>Entity changed</returns>
        definitionType ChangeVisibility(string name, AccessMode newVisibility);

        /// <summary>
        /// Remove all declared entities
        /// </summary>
        /// <returns>A list of removed entities</returns>
        List<definitionType> Clear();
    }
}
