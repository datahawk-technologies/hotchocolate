﻿using System.Collections.Generic;

namespace StrawberryShake.VisualStudio.Language
{
    public sealed class InputObjectTypeExtensionNode
        : InputObjectTypeDefinitionNodeBase
        , ITypeExtensionNode
    {
        public InputObjectTypeExtensionNode(
            Location location,
            NameNode name,
            IReadOnlyList<DirectiveNode> directives,
            IReadOnlyList<InputValueDefinitionNode> fields)
            : base(location, name, directives, fields)
        {
        }

        public override NodeKind Kind { get; } =
            NodeKind.InputObjectTypeExtension;

        public override IEnumerable<ISyntaxNode> GetNodes()
        {
            yield return Name;

            foreach (DirectiveNode directive in Directives)
            {
                yield return directive;
            }

            foreach (InputValueDefinitionNode field in Fields)
            {
                yield return field;
            }
        }

        public InputObjectTypeExtensionNode WithLocation(Location location)
        {
            return new InputObjectTypeExtensionNode(
                location, Name, Directives, Fields);
        }

        public InputObjectTypeExtensionNode WithName(NameNode name)
        {
            return new InputObjectTypeExtensionNode(
                Location, name, Directives, Fields);
        }

        public InputObjectTypeExtensionNode WithDirectives(
            IReadOnlyList<DirectiveNode> directives)
        {
            return new InputObjectTypeExtensionNode(
                Location, Name, directives, Fields);
        }

        public InputObjectTypeExtensionNode WithFields(
            IReadOnlyList<InputValueDefinitionNode> fields)
        {
            return new InputObjectTypeExtensionNode(
                Location, Name, Directives, fields);
        }
    }
}
